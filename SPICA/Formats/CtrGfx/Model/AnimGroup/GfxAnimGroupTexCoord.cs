﻿using SPICA.Formats.Common;

namespace SPICA.Formats.CtrGfx.Model.AnimGroup
{
    public class GfxAnimGroupTexCoord : GfxAnimGroupElement
    {
        private string _MaterialName;

        public string MaterialName
        {
            get
            {
                return _MaterialName;
            }
            set
            {
                _MaterialName = value ?? throw Exceptions.GetNullException("MaterialName");
            }
        }

        public int TexCoordIndex;

        private GfxAnimGroupObjType ObjType2;

        public GfxAnimGroupTexCoord()
        {
            ObjType = ObjType2 = GfxAnimGroupObjType.TexCoord;
        }
    }
}
