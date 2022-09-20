
// Примечание. Для запуска созданного кода может потребоваться NET Framework версии 4.5 или более поздней версии и .NET Core или Standard версии 2.0 или более поздней.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class Report
{

    private string gUID_FKField;

    private uint nOM_El_MESField;

    private string dATE_El_MESField;

    private uint iD_El_MESField;

    private uint nOM_PPField;

    private string dATE_PPField;

    private uint sUM_PPField;

    private ulong iNN_PLAT_PPField;

    private uint kPP_PLAT_PPField;

    private string kBKField;

    private uint oKATOField;

    private ulong iNN_RCV_PPField;

    private uint kPP_RCV_PPField;

    private uint iD_KOField;

    private ushort kOD_TOFKField;

    private string fIO_ISPField;

    private string tEL_ISPField;

    /// <remarks/>
    public string GUID_FK
    {
        get
        {
            return this.gUID_FKField;
        }
        set
        {
            this.gUID_FKField = value;
        }
    }

    /// <remarks/>
    public uint NOM_El_MES
    {
        get
        {
            return this.nOM_El_MESField;
        }
        set
        {
            this.nOM_El_MESField = value;
        }
    }

    /// <remarks/>
    public string DATE_El_MES
    {
        get
        {
            return this.dATE_El_MESField;
        }
        set
        {
            this.dATE_El_MESField = value;
        }
    }

    /// <remarks/>
    public uint ID_El_MES
    {
        get
        {
            return this.iD_El_MESField;
        }
        set
        {
            this.iD_El_MESField = value;
        }
    }

    /// <remarks/>
    public uint NOM_PP
    {
        get
        {
            return this.nOM_PPField;
        }
        set
        {
            nOM_PPField = value;
        }
    }

    /// <remarks/>
    public string DATE_PP
    {
        get
        {
            return this.dATE_PPField;
        }
        set
        {
            this.dATE_PPField = value;
        }
    }

    /// <remarks/>
    public uint SUM_PP
    {
        get
        {
            return this.sUM_PPField;
        }
        set
        {
            this.sUM_PPField = value;
        }
    }

    /// <remarks/>
    public ulong INN_PLAT_PP
    {
        get
        {
            return this.iNN_PLAT_PPField;
        }
        set
        {
            this.iNN_PLAT_PPField = value;
        }
    }

    /// <remarks/>
    public uint KPP_PLAT_PP
    {
        get
        {
            return this.kPP_PLAT_PPField;
        }
        set
        {
            this.kPP_PLAT_PPField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
    public string KBK
    {
        get
        {
            return this.kBKField;
        }
        set
        {
            this.kBKField = value;
        }
    }

    /// <remarks/>
    public uint OKATO
    {
        get
        {
            return this.oKATOField;
        }
        set
        {
            this.oKATOField = value;
        }
    }

    /// <remarks/>
    public ulong INN_RCV_PP
    {
        get
        {
            return this.iNN_RCV_PPField;
        }
        set
        {
            this.iNN_RCV_PPField = value;
        }
    }

    /// <remarks/>
    public uint KPP_RCV_PP
    {
        get
        {
            return this.kPP_RCV_PPField;
        }
        set
        {
            this.kPP_RCV_PPField = value;
        }
    }

    /// <remarks/>
    public uint ID_KO
    {
        get
        {
            return this.iD_KOField;
        }
        set
        {
            this.iD_KOField = value;
        }
    }

    /// <remarks/>
    public ushort KOD_TOFK
    {
        get
        {
            return this.kOD_TOFKField;
        }
        set
        {
            this.kOD_TOFKField = value;
        }
    }

    /// <remarks/>
    public string FIO_ISP
    {
        get
        {
            return this.fIO_ISPField;
        }
        set
        {
            this.fIO_ISPField = value;
        }
    }

    /// <remarks/>
    public string TEL_ISP
    {
        get
        {
            return this.tEL_ISPField;
        }
        set
        {
            this.tEL_ISPField = value;
        }
    }
}

