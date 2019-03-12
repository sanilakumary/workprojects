using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomUpholstery.BusinessObject;
using CustomUpholstery.DataAccessLayer;
namespace CustomUpholstery.BusinessLogic
{
    public class AttributeLogic
    {
        public List<AttributeDes> GetAllAttributes()
        {
            AttributeDal attributedal = new AttributeDal();
            var attributes = attributedal.GetAllAttributes();
            return attributes;
        }

    }
}
