// Примечание. Для запуска созданного кода может потребоваться NET Framework версии 4.5 или более поздней версии и .NET Core или Standard версии 2.0 или более поздней.
/// <remarks/>

 namespace MinjustXml;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
public partial class RegPP
{

    private string nOM_LINEField;

    private System.DateTime dATE_PAY_DOCField;

    private System.DateTime dATE_REESTR_PPField;

    private string sUM_REESTR_PPField;

    private string iD_OPERField;

    private string pAYMENT_IDField;

    private string iD_PLATField;

    private string iNN_PLATField;

    private string fIO_PLATField;

    private string aDRESS_PLATField;
     
    private string nOM_LS_PLATField;

    private ulong iNN_RCVField;

    private ulong nOM_LS_RCVField;

    private string nAME_RCVField;

    private string pURPOSEField;

    private string pAYSTATUSField;

    private string oSNPLATField;

    private string nAL_PERField;

    private string nUM_DOKField;

    private string dATE_DOKField;

    private string tYPE_PLField;

    private string nOM_LS_OFKField;

    private object tRANSAC_INFOField;

    /// <remarks/>
    public string NOM_LINE
    {
        get
        {
            return this.nOM_LINEField;
        }
        set
        {
            this.nOM_LINEField = value;
        }
    }
    public string GetDate
    {
        get { return DATE_PAY_DOC.ToString("hh:mm dd.MM.yyyy"); }

    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
    public System.DateTime DATE_PAY_DOC
    {
        get
        {
            return this.dATE_PAY_DOCField;
        }
        set
        {
            this.dATE_PAY_DOCField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
    public System.DateTime DATE_REESTR_PP
    {
        get
        {
            return this.dATE_REESTR_PPField;
        }
        set
        {
            this.dATE_REESTR_PPField = value;
        }
    }

    /// <remarks/>
    public string SUM_REESTR_PP
    {
        get
        {
            return this.sUM_REESTR_PPField;
        }
        set
        {
            this.sUM_REESTR_PPField = value;
        }
    }

    public string ID_OPER
    {
        get
        {
            return this.iD_OPERField;
        }
        set
        {
            this.iD_OPERField = value;
        }
    }

    /// <remarks/>
    public string PAYMENT_ID
    {
        get
        {
            return this.pAYMENT_IDField;
        }
        set
        {
            this.pAYMENT_IDField = value;
        }
    }

    public string ID_PLAT
    {
        get
        {
            return this.iD_PLATField;
        }
        set
        {
            this.iD_PLATField = value;
        }
    }

    /// <remarks/>
    public string INN_PLAT
    {
        get
        {
            return this.iNN_PLATField;
        }
        set
        {
            this.iNN_PLATField = value;
        }
    }

    /// <remarks/>
    public string FIO_PLAT
    {
        get
        {
            return this.fIO_PLATField;
        }
        set
        {
            this.fIO_PLATField = value;
        }
    }

    /// <remarks/>
    public string ADRESS_PLAT
    {
        get
        {
            return this.aDRESS_PLATField;
        }
        set
        {
            this.aDRESS_PLATField = value;
        }
    }

    public string NOM_LS_PLAT
    {
        get
        {
            return this.nOM_LS_PLATField;
        }
        set
        {
            this.nOM_LS_PLATField = value;
        }
    }

    /// <remarks/>
    public ulong INN_RCV
    {
        get
        {
            return this.iNN_RCVField;
        }
        set
        {
            this.iNN_RCVField = value;
        }
    }

    /// <remarks/>
    public ulong NOM_LS_RCV
    {
        get
        {
            return this.nOM_LS_RCVField;
        }
        set
        {
            this.nOM_LS_RCVField = value;
        }
    }

    /// <remarks/>
    public string NAME_RCV
    {
        get
        {
            return this.nAME_RCVField;
        }
        set
        {
            this.nAME_RCVField = value;
        }
    }

    /// <remarks/>
    public string PURPOSE
    {
        get
        {
            return this.pURPOSEField;
        }
        set
        {
            this.pURPOSEField = value;
        }
    }

    /// <remarks/>
    public string PAYSTATUS
    {
        get
        {
            return this.pAYSTATUSField;
        }
        set
        {
            this.pAYSTATUSField = value;
        }
    }

    /// <remarks/>
    public string OSNPLAT
    {
        get
        {
            return this.oSNPLATField;
        }
        set
        {
            this.oSNPLATField = value;
        }
    }

    /// <remarks/>
    public string NAL_PER
    {
        get
        {
            return this.nAL_PERField;
        }
        set
        {
            this.nAL_PERField = value;
        }
    }

    /// <remarks/>
    public string NUM_DOK
    {
        get
        {
            return this.nUM_DOKField;
        }
        set
        {
            this.nUM_DOKField = value;
        }
    }

    /// <remarks/>
    public string DATE_DOK
    {
        get
        {
            return this.dATE_DOKField;
        }
        set
        {
            this.dATE_DOKField = value;
        }
    }

    /// <remarks/>
    public string TYPE_PL
    {
        get
        {
            return this.tYPE_PLField;
        }
        set
        {
            this.tYPE_PLField = value;
        }
    }

    /// <remarks/>
    public string NOM_LS_OFK
    {
        get
        {
            return this.nOM_LS_OFKField;
        }
        set
        {
            this.nOM_LS_OFKField = value;
        }
    }

    /// <remarks/>
    public object TRANSAC_INFO
    {
        get
        {
            return this.tRANSAC_INFOField;
        }
        set
        {
            this.tRANSAC_INFOField = value;
        }
    }
}

