using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCLBBO;
using PCLDAL;

namespace PCLBBL
{
  public  class ModelBLL
    {
      public int InsertModel(Model model)
      { 
          ModelDAL modal = new ModelDAL();
          int  Results = modal.InsertModel(model);
          return Results;
      }
      public List<Model> GetModel()
      {
          ModelDAL modal = new ModelDAL();
          return modal.GetModel();
      }
      public int UpdateModel(Model model)
      {
          ModelDAL modal = new ModelDAL();
          return modal.UpdateModel(model);
      }

      public Model GetModelDetails(int modelId)
      {
          ModelDAL modal = new ModelDAL();
          return modal.GetModelDetails(modelId);
      }
      public int DeleteMultipleRecords(List<string> idCollection)
      {
          ModelDAL modal = new ModelDAL();
          return modal.DeleteMultipleRecords(idCollection);
      }
      public List<Model> GetModelDetailsByName(string modelname)
      {
          ModelDAL modal = new ModelDAL();
          return modal.GetModelDetailsByName(modelname);
      }
    }
}
