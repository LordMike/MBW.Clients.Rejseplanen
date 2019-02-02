//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 2.0.206.0.
namespace MBW.Clients.Rejseplanen.Schema.RestArrivalBoard
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Xml.Serialization;
    
    
    /// <summary>
    /// <para>The arrival board lists up to 20 arrivals at a specific stop/station or group of stop/stations.</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute("The arrival board lists up to 20 arrivals at a specific stop/station or group of " +
        "stop/stations.")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.206.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("ArrivalBoard", Namespace="", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("ArrivalBoard", Namespace="")]
    public partial class ArrivalBoard : IAttlistPeriodArrivalBoard
    {
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<Arrival> _arrival;
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Arrival", Namespace="")]
        public System.Collections.ObjectModel.Collection<Arrival> Arrival
        {
            get
            {
                return this._arrival;
            }
            private set
            {
                this._arrival = value;
            }
        }
        
        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die Arrival-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the Arrival collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ArrivalSpecified
        {
            get
            {
                return (this.Arrival.Count != 0);
            }
        }
        
        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="ArrivalBoard" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="ArrivalBoard" /> class.</para>
        /// </summary>
        public ArrivalBoard()
        {
            this._arrival = new System.Collections.ObjectModel.Collection<Arrival>();
        }
        
        /// <summary>
        /// <para>If some problem occurs while creating the arrival board you can find an error code here. Note: These error codes are not suitable for end users but only for reporting purposes. Most of the errors do not indicate a system failure but data or request parameter issues.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute(@"If some problem occurs while creating the arrival board you can find an error code here. Note: These error codes are not suitable for end users but only for reporting purposes. Most of the errors do not indicate a system failure but data or request parameter issues.")]
        [System.Xml.Serialization.XmlAttributeAttribute("error", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Error { get; set; }
    }
    
    /// <summary>
    /// <para>The element Arrival contains all information about a arrival like time, date, stop/station name, track, realtime time, date and track, origin, name and type of the journey. It also contains a reference to journey details.</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute("The element Arrival contains all information about a arrival like time, date, sto" +
        "p/station name, track, realtime time, date and track, origin, name and type of t" +
        "he journey. It also contains a reference to journey details.")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.206.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("Arrival", Namespace="", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("Arrival", Namespace="")]
    public partial class Arrival : IAttlistPeriodArrival
    {
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("JourneyDetailRef", Namespace="")]
        public JourneyDetailRef JourneyDetailRef { get; set; }
        
        /// <summary>
        /// <para>The attribute name specifies the name of the arriving journey (e.g. "Bus 100").</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("The attribute name specifies the name of the arriving journey (e.g. \"Bus 100\").")]
        [System.Xml.Serialization.XmlAttributeAttribute("name", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name { get; set; }
        
        /// <summary>
        /// <para>The attribute type specifies the type of the arriving journey. Valid values are IC (InterCity), LYN (Lyntog), REG (Regionaltog), S (S-Tog), TOG (other train), BUS (Bus), EXB (Express Buss), NB (Nattbus), TB (Telebus, other form of transport), F (Ferry), M (Metro) and LET (Letbane).</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute(@"The attribute type specifies the type of the arriving journey. Valid values are IC (InterCity), LYN (Lyntog), REG (Regionaltog), S (S-Tog), TOG (other train), BUS (Bus), EXB (Express Buss), NB (Nattbus), TB (Telebus, other form of transport), F (Ferry), M (Metro) and LET (Letbane).")]
        [System.Xml.Serialization.XmlAttributeAttribute("type", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public IAttlistPeriodArrivalType Type { get; set; }
        
        /// <summary>
        /// <para>Contains the name of the stop/station.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Contains the name of the stop/station.")]
        [System.Xml.Serialization.XmlAttributeAttribute("stop", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Stop { get; set; }
        
        /// <summary>
        /// <para>Time in format HH:MM.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Time in format HH:MM.")]
        [System.Xml.Serialization.XmlAttributeAttribute("time", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Time { get; set; }
        
        /// <summary>
        /// <para>Date in format DD.MM.YY.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Date in format DD.MM.YY.")]
        [System.Xml.Serialization.XmlAttributeAttribute("date", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Date { get; set; }
        
        /// <summary>
        /// <para>Track information, if available.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Track information, if available.")]
        [System.Xml.Serialization.XmlAttributeAttribute("track", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Track { get; set; }
        
        /// <summary>
        /// <para>Realtime time in format HH:MM if available.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Realtime time in format HH:MM if available.")]
        [System.Xml.Serialization.XmlAttributeAttribute("rtTime", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RtTime { get; set; }
        
        /// <summary>
        /// <para>Realtime date in format DD.MM.YY, if available.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Realtime date in format DD.MM.YY, if available.")]
        [System.Xml.Serialization.XmlAttributeAttribute("rtDate", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RtDate { get; set; }
        
        /// <summary>
        /// <para>Realtime track information, if available.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Realtime track information, if available.")]
        [System.Xml.Serialization.XmlAttributeAttribute("rtTrack", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RtTrack { get; set; }
        
        /// <summary>
        /// <para>Origin of the journey.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Origin of the journey.")]
        [System.Xml.Serialization.XmlAttributeAttribute("origin", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Origin { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private bool _cancelled = false;
        
        /// <summary>
        /// <para>This attribute gives information whether this journey is cancelled</para>
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute(false)]
        [System.ComponentModel.DescriptionAttribute("This attribute gives information whether this journey is cancelled")]
        [System.Xml.Serialization.XmlAttributeAttribute("cancelled", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool Cancelled
        {
            get
            {
                return this._cancelled;
            }
            set
            {
                this._cancelled = value;
            }
        }
        
        /// <summary>
        /// <para>This attribute gives the number of messages for this journey</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("This attribute gives the number of messages for this journey")]
        [System.Xml.Serialization.XmlAttributeAttribute("messages", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Messages { get; set; }
        
        /// <summary>
        /// <para>This attribute gives the state of the current journey</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("This attribute gives the state of the current journey")]
        [System.Xml.Serialization.XmlAttributeAttribute("state", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string State { get; set; }
    }
    
    /// <summary>
    /// <para>Reference to journey details.</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute("Reference to journey details.")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.206.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("JourneyDetailRef", Namespace="", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("JourneyDetailRef", Namespace="")]
    public partial class JourneyDetailRef : IAttlistPeriodJourneyDetailRef
    {
        
        /// <summary>
        /// <para>Contains a URL to call the ReST interface for journey details.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Contains a URL to call the ReST interface for journey details.")]
        [System.Xml.Serialization.XmlAttributeAttribute("ref", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Ref { get; set; }
    }
    
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.206.0")]
    public partial interface IAttlistPeriodJourneyDetailRef
    {
        
        /// <summary>
        /// <para>Contains a URL to call the ReST interface for journey details.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Contains a URL to call the ReST interface for journey details.")]
        string Ref
        {
            get;
            set;
        }
    }
    
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.206.0")]
    public partial interface IAttlistPeriodArrival
    {
        
        /// <summary>
        /// <para>The attribute name specifies the name of the arriving journey (e.g. "Bus 100").</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("The attribute name specifies the name of the arriving journey (e.g. \"Bus 100\").")]
        string Name
        {
            get;
            set;
        }
        
        /// <summary>
        /// <para>The attribute type specifies the type of the arriving journey. Valid values are IC (InterCity), LYN (Lyntog), REG (Regionaltog), S (S-Tog), TOG (other train), BUS (Bus), EXB (Express Buss), NB (Nattbus), TB (Telebus, other form of transport), F (Ferry), M (Metro) and LET (Letbane).</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute(@"The attribute type specifies the type of the arriving journey. Valid values are IC (InterCity), LYN (Lyntog), REG (Regionaltog), S (S-Tog), TOG (other train), BUS (Bus), EXB (Express Buss), NB (Nattbus), TB (Telebus, other form of transport), F (Ferry), M (Metro) and LET (Letbane).")]
        IAttlistPeriodArrivalType Type
        {
            get;
            set;
        }
        
        /// <summary>
        /// <para>Contains the name of the stop/station.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Contains the name of the stop/station.")]
        string Stop
        {
            get;
            set;
        }
        
        /// <summary>
        /// <para>Time in format HH:MM.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Time in format HH:MM.")]
        string Time
        {
            get;
            set;
        }
        
        /// <summary>
        /// <para>Date in format DD.MM.YY.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Date in format DD.MM.YY.")]
        string Date
        {
            get;
            set;
        }
        
        /// <summary>
        /// <para>Track information, if available.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Track information, if available.")]
        string Track
        {
            get;
            set;
        }
        
        /// <summary>
        /// <para>Realtime time in format HH:MM if available.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Realtime time in format HH:MM if available.")]
        string RtTime
        {
            get;
            set;
        }
        
        /// <summary>
        /// <para>Realtime date in format DD.MM.YY, if available.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Realtime date in format DD.MM.YY, if available.")]
        string RtDate
        {
            get;
            set;
        }
        
        /// <summary>
        /// <para>Realtime track information, if available.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Realtime track information, if available.")]
        string RtTrack
        {
            get;
            set;
        }
        
        /// <summary>
        /// <para>Origin of the journey.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Origin of the journey.")]
        string Origin
        {
            get;
            set;
        }
        
        /// <summary>
        /// <para>This attribute gives information whether this journey is cancelled</para>
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute(false)]
        [System.ComponentModel.DescriptionAttribute("This attribute gives information whether this journey is cancelled")]
        bool Cancelled
        {
            get;
            set;
        }
        
        /// <summary>
        /// <para>This attribute gives the number of messages for this journey</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("This attribute gives the number of messages for this journey")]
        string Messages
        {
            get;
            set;
        }
        
        /// <summary>
        /// <para>This attribute gives the state of the current journey</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("This attribute gives the state of the current journey")]
        string State
        {
            get;
            set;
        }
    }
    
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.206.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("IAttlistPeriodArrivalType", Namespace="")]
    public enum IAttlistPeriodArrivalType
    {
        
        /// <summary>
        /// </summary>
        IC,
        
        /// <summary>
        /// </summary>
        LYN,
        
        /// <summary>
        /// </summary>
        REG,
        
        /// <summary>
        /// </summary>
        S,
        
        /// <summary>
        /// </summary>
        TOG,
        
        /// <summary>
        /// </summary>
        BUS,
        
        /// <summary>
        /// </summary>
        EXB,
        
        /// <summary>
        /// </summary>
        NB,
        
        /// <summary>
        /// </summary>
        TB,
        
        /// <summary>
        /// </summary>
        F,
        
        /// <summary>
        /// </summary>
        M,
        
        /// <summary>
        /// </summary>
        LET,
    }
    
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.206.0")]
    public partial interface IAttlistPeriodArrivalBoard
    {
        
        /// <summary>
        /// <para>If some problem occurs while creating the arrival board you can find an error code here. Note: These error codes are not suitable for end users but only for reporting purposes. Most of the errors do not indicate a system failure but data or request parameter issues.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute(@"If some problem occurs while creating the arrival board you can find an error code here. Note: These error codes are not suitable for end users but only for reporting purposes. Most of the errors do not indicate a system failure but data or request parameter issues.")]
        string Error
        {
            get;
            set;
        }
    }
}
