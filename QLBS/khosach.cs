using System;
using System.Collections.Generic;


namespace QLBS
{
   
    class khosach
    {
       
        public khosach(string tsach,int slnhap)
        {
            this.tsach = tsach;
            this.slnhap = slnhap;
            this.slban = 0;
            this.tonkho = slnhap - slban;
        }

        public khosach(string tsach,int slnhap,int slban)
        {
            this.tsach = tsach;
            this.slnhap = slnhap;
            this.slban = slban;
            this.tonkho = slnhap - slban;
        }
        
        public string tsach { get; set; }
        public int slnhap { get; set; }
        public int slban { get; set; }
        public int tonkho { get; set; }

    }
    
}
