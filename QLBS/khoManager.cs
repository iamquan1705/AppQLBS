using System;
using System.Collections.Generic;

namespace QLBS
{
    class khoManager
    {


        public khoManager()
        {
            listkho = new List<khosach>();
        }
        public int timkiem(string tsach)
        {
            int tk = 0;
            for (int i = 0; i < listkho.Count; i++)
            {
                if (listkho[i].tsach==tsach)
                {
                    tk = listkho[i].tonkho;
                }
            }
            return tk;
        }

        public void addKho(khosach ks )
        {
            listkho.Add(ks);
        }
        public void editKho(khosach ks)
        {
            for (int i=0; i < listkho.Count;i++)
            {
                if (listkho[i].tsach.Equals(ks.tsach))
                {
                    listkho[i].slban = ks.slban  ;
                    listkho[i].tonkho = listkho[i].slnhap - ks.slban;
                }
            }
        }

        public khoManager(List<khosach> listkho)
        {
            this.listkho = listkho;
        }
        public List<khosach> listkho { get; set; }



    }
}
