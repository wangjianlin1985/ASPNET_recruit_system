using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*简历投递业务逻辑层*/
    public class bllDelivery{
        /*添加简历投递*/
        public static bool AddDelivery(ENTITY.Delivery delivery)
        {
            return DAL.dalDelivery.AddDelivery(delivery);
        }

        /*根据deliveryId获取某条简历投递记录*/
        public static ENTITY.Delivery getSomeDelivery(int deliveryId)
        {
            return DAL.dalDelivery.getSomeDelivery(deliveryId);
        }

        /*更新简历投递*/
        public static bool EditDelivery(ENTITY.Delivery delivery)
        {
            return DAL.dalDelivery.EditDelivery(delivery);
        }

        /*删除简历投递*/
        public static bool DelDelivery(string p)
        {
            return DAL.dalDelivery.DelDelivery(p);
        }

        /*查询简历投递*/
        public static System.Data.DataSet GetDelivery(string strWhere)
        {
            return DAL.dalDelivery.GetDelivery(strWhere);
        }

       


        /*根据条件分页查询简历投递*/
        public static System.Data.DataTable GetDelivery(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalDelivery.GetDelivery(NowPage, PageSize, out AllPage, out DataCount, p);
        }

        /*根据条件分页查询简历投递*/
        public static System.Data.DataTable GetDelivery2(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalDelivery.GetDelivery2(NowPage, PageSize, out AllPage, out DataCount, p);
        }


        /*查询所有的简历投递*/
        public static System.Data.DataSet getAllDelivery()
        {
            return DAL.dalDelivery.getAllDelivery();
        }
    }
}
