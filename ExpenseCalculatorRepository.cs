using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ExpenseCalculatorWebApi.BusinessObjects;
using ExpenseCalculatorWebApi.Common;
using System.Data;
using System.Data.Common;
using Common.Constants;
using ExpenseCalculatorWebApi.ExpenseCalculatorDataAccess;

namespace ExpenseCalculatorWebApi.ExpenseCalculatorDataAccess
{
    public class ExpenseCalculatorRepository : IExpenseCalculatorRepository
    {
        public List<ExpenseData> GetExpenses(DateTime startDate, DateTime endDate)
        {
            //errorCode = null;
            List<ExpenseData> expenseCollection = null;
            ExpenseData expData = null;

            try
            {
               
                using (SqlConnection connection = new SqlConnection(DBConstants.EXPENSECALCULATOR_CONNECTIONSTRING))
                {
                    connection.Open();                    
                    SqlCommand command = new SqlCommand(DBConstants.GET_EXPENSES,connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // adding parameters into the command object

                    command.Parameters.Add(new SqlParameter(DBConstants.START_DATE_PARAM, startDate));
                    command.Parameters.Add(new SqlParameter(DBConstants.END_DATE_PARAM, endDate));                    

                    expenseCollection = new List<ExpenseData>();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            expData = new ExpenseData();

                            if (!Convert.IsDBNull(dataReader[DBConstants.EXPENSE_ID_COLUMN]))
                            {
                                expData.expenseDataId = (int)(dataReader[DBConstants.EXPENSE_ID_COLUMN]);
                            }

                            if (!Convert.IsDBNull(dataReader[DBConstants.EXPENSE_TYPE_ID_COLUMN]))
                            {
                                expData.expenseTypeId = (int)dataReader[DBConstants.EXPENSE_TYPE_ID_COLUMN];
                            }

                            if (!Convert.IsDBNull(dataReader[DBConstants.EXPENSE_TYPE_NAME_COLUMN]))
                            {
                                expData.expenseTypeName = dataReader[DBConstants.EXPENSE_TYPE_NAME_COLUMN].ToString();
                            }

                            if (!Convert.IsDBNull(dataReader[DBConstants.STORE_ID_COLUMN]))
                            {
                                expData.purchaseStoreId = (int)dataReader[DBConstants.STORE_ID_COLUMN];
                            }

                            if (!Convert.IsDBNull(dataReader[DBConstants.STORE_NAME_COLUMN]))
                            {
                                expData.purchaseStoreName = dataReader[DBConstants.STORE_NAME_COLUMN].ToString();
                            }

                            if (!Convert.IsDBNull(dataReader[DBConstants.EXPENSE_DATE_COLUMN]))
                            {
                                expData.expenseDate = (DateTime)dataReader[DBConstants.EXPENSE_DATE_COLUMN];
                            }

                            if (!Convert.IsDBNull(dataReader[DBConstants.AMOUNT_COLUMN]))
                            {
                                expData.spentAmount = Convert.ToDouble(dataReader[DBConstants.AMOUNT_COLUMN]);
                            }

                            expenseCollection.Add(expData);
                            expData = null;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Utilities.HandleError(exception);
                //errorCode = MessageConstants.GET_EXPENSES_ERROR;
            }
            return expenseCollection;
        }

        public List<ExpenseData> GetExpenses(int expType, DateTime startDate, DateTime endDate)
        {
            //errorCode = null;
            List<ExpenseData> expenseCollection = null;
            ExpenseData expData = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConstants.EXPENSECALCULATOR_CONNECTIONSTRING))
                {
                    connection.Open();                   

                    SqlCommand Command = new SqlCommand(DBConstants.GET_ITEMISED_EXPENSES,connection);
                    Command.CommandType = CommandType.StoredProcedure;
                    // adding parameters into the command object

                    Command.Parameters.Add(new SqlParameter(DBConstants.EXPENSE_TYPE_ID_PARAM, expType));
                    Command.Parameters.Add(new SqlParameter(DBConstants.START_DATE_PARAM, startDate));
                    Command.Parameters.Add(new SqlParameter(DBConstants.END_DATE_PARAM,  endDate));              

                    
                    expenseCollection = new List<ExpenseData>();
                    using (SqlDataReader dataReader = Command.ExecuteReader())
                    {

                        expenseCollection = new List<ExpenseData>();

                        while (dataReader.Read())
                        {
                            expData = new ExpenseData();

                            if (!Convert.IsDBNull(dataReader[DBConstants.EXPENSE_ID_COLUMN]))
                            {
                                expData.expenseDataId = (int)(dataReader[DBConstants.EXPENSE_ID_COLUMN]);
                            }

                            if (!Convert.IsDBNull(dataReader[DBConstants.EXPENSE_TYPE_ID_COLUMN]))
                            {
                                expData.expenseTypeId = (int)dataReader[DBConstants.EXPENSE_TYPE_ID_COLUMN];
                            }

                            if (!Convert.IsDBNull(dataReader[DBConstants.EXPENSE_TYPE_NAME_COLUMN]))
                            {
                                expData.expenseTypeName = dataReader[DBConstants.EXPENSE_TYPE_NAME_COLUMN].ToString();
                            }

                            if (!Convert.IsDBNull(dataReader[DBConstants.STORE_ID_COLUMN]))
                            {
                                expData.purchaseStoreId = (int)dataReader[DBConstants.STORE_ID_COLUMN];
                            }

                            if (!Convert.IsDBNull(dataReader[DBConstants.STORE_NAME_COLUMN]))
                            {
                                expData.purchaseStoreName = dataReader[DBConstants.STORE_NAME_COLUMN].ToString();
                            }

                            if (!Convert.IsDBNull(dataReader[DBConstants.EXPENSE_DATE_COLUMN]))
                            {
                                expData.expenseDate = (DateTime)dataReader[DBConstants.EXPENSE_DATE_COLUMN];
                            }

                            if (!Convert.IsDBNull(dataReader[DBConstants.AMOUNT_COLUMN]))
                            {
                                expData.spentAmount = Convert.ToDouble(dataReader[DBConstants.AMOUNT_COLUMN]);
                            }

                            expenseCollection.Add(expData);
                            expData = null;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Utilities.HandleError(exception);
                //errorCode = MessageConstants.GET_EXPENSES_ERROR;
            }
            return expenseCollection;
        }

        public ExpenseData GetExpenseDetails(int id)
        {
            //errorCode = null;
            ExpenseData expData = null;
            try
            {
                
                using (SqlConnection connection = new SqlConnection(DBConstants.EXPENSECALCULATOR_CONNECTIONSTRING))
                {
                    connection.Open();
                    SqlCommand Command = new SqlCommand(DBConstants.GET_EXPENSE_DETAILS_ID, connection);
                    Command.CommandType = CommandType.StoredProcedure;
                   
                    // adding parameters into the command object

                    Command.Parameters.Add(new SqlParameter(DBConstants.EXPENSE_ID_PARAM,Convert.ToInt32(id)));
                    using (SqlDataReader dataReader = Command.ExecuteReader())
                    {

                        expData = new ExpenseData();
                        while (dataReader.Read())
                        {
                           
                            
                            if (!Convert.IsDBNull(dataReader[DBConstants.EXPENSE_TYPE_ID_COLUMN]))
                            {
                                expData.expenseTypeId = (int)dataReader[DBConstants.EXPENSE_TYPE_ID_COLUMN];
                            }                            

                            if (!Convert.IsDBNull(dataReader[DBConstants.STORE_ID_COLUMN]))
                            {
                                expData.purchaseStoreId = (int)dataReader[DBConstants.STORE_ID_COLUMN];
                            }                                                     

                            if (!Convert.IsDBNull(dataReader[DBConstants.EXPENSE_DATE_COLUMN]))
                            {
                                expData.expenseDate = (DateTime)dataReader[DBConstants.EXPENSE_DATE_COLUMN];
                            }

                            if (!Convert.IsDBNull(dataReader[DBConstants.AMOUNT_COLUMN]))
                            {
                                expData.spentAmount = Convert.ToDouble(dataReader[DBConstants.AMOUNT_COLUMN]);
                            }
                            if (!Convert.IsDBNull(dataReader[DBConstants.EXPENSE_ID_COLUMN]))
                            {
                                expData.expenseDataId = (int)(dataReader[DBConstants.EXPENSE_ID_COLUMN]);
                            }
                            if (!Convert.IsDBNull(dataReader[DBConstants.EXPENSE_TYPE_NAME_COLUMN]))
                            {
                                expData.expenseTypeName = dataReader[DBConstants.EXPENSE_TYPE_NAME_COLUMN].ToString();
                            }
                            if (!Convert.IsDBNull(dataReader[DBConstants.STORE_NAME_COLUMN]))
                            {
                                expData.purchaseStoreName = dataReader[DBConstants.STORE_NAME_COLUMN].ToString();
                            }

                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Utilities.HandleError(exception);
                //errorCode = MessageConstants.GET_EXPENSE_DETAILS_ERROR;
            }
            return expData;
        }

       
        public bool CreateExpense(ExpenseData expData)
        {
           
            int result;

            try
            {
                

                using (SqlConnection connection = new SqlConnection(DBConstants.EXPENSECALCULATOR_CONNECTIONSTRING))
                {
                    connection.Open();
                    SqlCommand Command = new SqlCommand(DBConstants.CREATE_EXPENSE,connection);
                    Command.CommandType = CommandType.StoredProcedure;
                    // adding parameters into the command object

                    Command.Parameters.Add(new SqlParameter(DBConstants.EXPENSE_TYPE_ID_PARAM,  expData.expenseTypeId));
                    Command.Parameters.Add(new SqlParameter(DBConstants.STORE_ID_PARAM,  expData.purchaseStoreId));
                    Command.Parameters.Add(new SqlParameter(DBConstants.EXPENSE_DATE_PARAM, expData.expenseDate));
                    Command.Parameters.Add(new SqlParameter(DBConstants.AMOUNT_PARAM,  expData.spentAmount));

                    result = Command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                
            }

            catch (Exception exception)
            {
                throw exception;
            }
           
        }

       


      
        public string UpdateExpense(ExpenseData expData)
        {
            int result;

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConstants.EXPENSECALCULATOR_CONNECTIONSTRING))
                {

                    connection.Open();
                    SqlCommand Command = new SqlCommand(DBConstants.UPDATE_EXPENSE,connection);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.Add(new SqlParameter(DBConstants.EXPENSE_ID_PARAM,  expData.expenseDataId));
                    Command.Parameters.Add(new SqlParameter( DBConstants.EXPENSE_TYPE_ID_PARAM,  expData.expenseTypeId));
                    Command.Parameters.Add(new SqlParameter( DBConstants.STORE_ID_PARAM,  expData.purchaseStoreId));
                    Command.Parameters.Add(new SqlParameter( DBConstants.EXPENSE_DATE_PARAM,  expData.expenseDate));
                    Command.Parameters.Add(new SqlParameter( DBConstants.AMOUNT_PARAM,  expData.spentAmount));                  

                    result = Command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return "Successfully updated of employee records";
                    }
                    else
                    {
                        return "Updation failed";
                    }
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

       
        public string DeleteExpense(int id)
        {
            int result;

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConstants.EXPENSECALCULATOR_CONNECTIONSTRING))
                {
                    connection.Open();
                    SqlCommand Command = new SqlCommand(DBConstants.DELETE_EXPENSE, connection);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.Add(new SqlParameter(DBConstants.EXPENSE_ID_PARAM, Convert.ToInt32(id)));

                    result = Command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return "Successfully deleted of employee records";
                    }
                    else
                    {
                        return "Deletion failed";
                    }

                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        
      
        public List<ExpenseType> GetExpenseTypes()
        {
            //errorCode = null;
            List<ExpenseType> expenseTypeCollection = null;
            ExpenseType expType = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConstants.EXPENSECALCULATOR_CONNECTIONSTRING))
                {

                    connection.Open();
                    SqlCommand command = new SqlCommand(DBConstants.GET_EXPENSE_TYPES, connection);

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {

                        expenseTypeCollection = new List<ExpenseType>();

                        while (dataReader.Read())
                        {
                            expType = new ExpenseType();

                            if (!Convert.IsDBNull(dataReader[DBConstants.EXPENSE_TYPE_ID_COLUMN]))
                            {
                                expType.expenseTypeId = (int)(dataReader[DBConstants.EXPENSE_TYPE_ID_COLUMN]);
                            }

                            if (!Convert.IsDBNull(dataReader[DBConstants.EXPENSE_TYPE_NAME_COLUMN]))
                            {
                                expType.expenseTypeName = dataReader[DBConstants.EXPENSE_TYPE_NAME_COLUMN].ToString();
                            }

                            expenseTypeCollection.Add(expType);
                            
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Utilities.HandleError(exception);
                //errorCode = MessageConstants.GET_EXPENSE_TYPES_ERROR;
            }
            return expenseTypeCollection;
        }

      
        public List<Store> GetStores()
        {
            //errorCode = null;
            List<Store> storeCollection = null;
            Store storeObject = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConstants.EXPENSECALCULATOR_CONNECTIONSTRING))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(DBConstants.GET_STORES, connection);

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {

                        storeCollection = new List<Store>();

                        while (dataReader.Read())
                        {
                            storeObject = new Store();

                            if (!Convert.IsDBNull(dataReader[DBConstants.STORE_ID_COLUMN]))
                            {
                                storeObject.storeId = (int)(dataReader[DBConstants.STORE_ID_COLUMN]);
                            }

                            if (!Convert.IsDBNull(dataReader[DBConstants.STORE_NAME_COLUMN]))
                            {
                                storeObject.storeName = dataReader[DBConstants.STORE_NAME_COLUMN].ToString();
                            }

                            storeCollection.Add(storeObject);
                            storeObject = null;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Utilities.HandleError(exception);
                //errorCode = MessageConstants.GET_STORES_ERROR;
            }
            return storeCollection;
        }

        #endregion
        public List<ReportType> GetReportTypes()
        {
            //errorCode = null;
            List<ReportType> reportTypeCollection = null;
            ReportType rptType = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConstants.EXPENSECALCULATOR_CONNECTIONSTRING))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(DBConstants.GET_REPORT_TYPES, connection);

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {

                        reportTypeCollection = new List<ReportType>();

                        while (dataReader.Read())
                        {
                            rptType = new ReportType();

                            if (!Convert.IsDBNull(dataReader[DBConstants.REPORT_TYPE_ID_COLUMN]))
                            {
                                rptType.reportTypeId = dataReader[DBConstants.REPORT_TYPE_ID_COLUMN].ToString();
                            }

                            if (!Convert.IsDBNull(dataReader[DBConstants.REPORT_TYPE_NAME_COLUMN]))
                            {
                                rptType.reportTypeName = dataReader[DBConstants.REPORT_TYPE_NAME_COLUMN].ToString();
                            }

                            reportTypeCollection.Add(rptType);
                            rptType = null;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Utilities.HandleError(exception);
               // errorCode = MessageConstants.GET_REPORT_TYPES_ERROR;
            }
            return reportTypeCollection;
        }
       
    }
}
