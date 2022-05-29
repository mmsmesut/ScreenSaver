using Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaver.Entity
{
    public class ScreenShot : BaseEntity
    {
        public string ImageName { get; set; }

        public byte[] ImageByte { get; set; }
    }
}
