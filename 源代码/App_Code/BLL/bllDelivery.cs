using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*����Ͷ��ҵ���߼���*/
    public class bllDelivery{
        /*��Ӽ���Ͷ��*/
        public static bool AddDelivery(ENTITY.Delivery delivery)
        {
            return DAL.dalDelivery.AddDelivery(delivery);
        }

        /*����deliveryId��ȡĳ������Ͷ�ݼ�¼*/
        public static ENTITY.Delivery getSomeDelivery(int deliveryId)
        {
            return DAL.dalDelivery.getSomeDelivery(deliveryId);
        }

        /*���¼���Ͷ��*/
        public static bool EditDelivery(ENTITY.Delivery delivery)
        {
            return DAL.dalDelivery.EditDelivery(delivery);
        }

        /*ɾ������Ͷ��*/
        public static bool DelDelivery(string p)
        {
            return DAL.dalDelivery.DelDelivery(p);
        }

        /*��ѯ����Ͷ��*/
        public static System.Data.DataSet GetDelivery(string strWhere)
        {
            return DAL.dalDelivery.GetDelivery(strWhere);
        }

       


        /*����������ҳ��ѯ����Ͷ��*/
        public static System.Data.DataTable GetDelivery(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalDelivery.GetDelivery(NowPage, PageSize, out AllPage, out DataCount, p);
        }

        /*����������ҳ��ѯ����Ͷ��*/
        public static System.Data.DataTable GetDelivery2(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalDelivery.GetDelivery2(NowPage, PageSize, out AllPage, out DataCount, p);
        }


        /*��ѯ���еļ���Ͷ��*/
        public static System.Data.DataSet getAllDelivery()
        {
            return DAL.dalDelivery.getAllDelivery();
        }
    }
}
