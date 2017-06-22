﻿using SPICA.Formats.Common;

namespace SPICA.Formats.CtrGfx.Model.AnimGroup
{
    class GfxAnimGroupBone : GfxAnimGroupElement
    {
        private string _BoneName;

        public string BoneName
        {
            get
            {
                return _BoneName;
            }
            set
            {
                _BoneName = value ?? throw Exceptions.GetNullException("BoneName");
            }
        }

        private GfxAnimGroupObjType ObjType2;

        public GfxAnimGroupBone()
        {
            ObjType = ObjType2 = GfxAnimGroupObjType.Bone;
        }
    }
}
