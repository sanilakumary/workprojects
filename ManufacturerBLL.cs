using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PCLBBO;
using PCLDAL;

namespace PCLBBL
{
    public class ManufacturerBLL
    {

        public int InsertManufacturer(Manufacturer manufacturer)
        {
            int Results;
            ManufacturerDAL dal = new ManufacturerDAL();
            Results = dal.InsertManufacturer(manufacturer);
            return Results;
        }
        public List<Manufacturer> GetManufacturer()
        {
            ManufacturerDAL mdal = new ManufacturerDAL();
            return mdal.GetManufacturer();
        }
        public int UpdateManufacturer(Manufacturer manufacturer)
        {
            ManufacturerDAL mdal = new ManufacturerDAL();
            return mdal.UpdateManufacturer(manufacturer);
        }

        public Manufacturer GetManufacturDetails(int manufactureId)
        {
            ManufacturerDAL mdal = new ManufacturerDAL();
            return mdal.GetManufactureDetails(manufactureId);
        }
        public int DeleteMultipleRecords(List<string> idCollection)
        {
            ManufacturerDAL mdal = new ManufacturerDAL();
            return mdal.DeleteMultipleRecords(idCollection);
        }
        public List<Manufacturer> GetManufactDetailsByName(string manufactname)
        {
            ManufacturerDAL mdal = new ManufacturerDAL();
            return mdal.GetManufactDetailsByName(manufactname);
        }
    }
}
