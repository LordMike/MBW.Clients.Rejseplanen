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
namespace MBW.Clients.Rejseplanen.Schema.RestStopsNearby
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Xml.Serialization;
    
    
    /// <summary>
    /// <para>The location list contains stops/stations with
    ///                name, id, coordinate and distance (as the crow flies) as a 
    ///                result of a stops nearby request. The data of every list entry 
    ///                can be used for further trip or departureBoard requests.</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute("The location list contains stops/stations with name, id, coordinate and distance " +
        "(as the crow flies) as a result of a stops nearby request. The data of every lis" +
        "t entry can be used for further trip or departureBoard requests.")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.206.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("LocationList", Namespace="", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("LocationList", Namespace="")]
    public partial class LocationList
    {
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<StopLocation> _stopLocation;
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("StopLocation", Namespace="")]
        public System.Collections.ObjectModel.Collection<StopLocation> StopLocation
        {
            get
            {
                return this._stopLocation;
            }
            private set
            {
                this._stopLocation = value;
            }
        }
        
        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die StopLocation-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the StopLocation collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StopLocationSpecified
        {
            get
            {
                return (this.StopLocation.Count != 0);
            }
        }
        
        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="LocationList" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="LocationList" /> class.</para>
        /// </summary>
        public LocationList()
        {
            this._stopLocation = new System.Collections.ObjectModel.Collection<StopLocation>();
        }
    }
    
    /// <summary>
    /// <para>The element StopLocation specifies  a stop/station in a result of a location request. It contains an  output name and an id.</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute("The element StopLocation specifies a stop/station in a result of a location reque" +
        "st. It contains an output name and an id.")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.206.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("StopLocation", Namespace="", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("StopLocation", Namespace="")]
    public partial class StopLocation : IAttlistPeriodStopLocation
    {
        
        /// <summary>
        /// <para>Contains the output name of this stop or station</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Contains the output name of this stop or station")]
        [System.Xml.Serialization.XmlAttributeAttribute("name", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name { get; set; }
        
        /// <summary>
        /// <para>The WGS84 x coordinate as integer (multiplied by 1,000,000)</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("The WGS84 x coordinate as integer (multiplied by 1,000,000)")]
        [System.Xml.Serialization.XmlAttributeAttribute("x", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int X { get; set; }
        
        /// <summary>
        /// <para>The WGS84 y coordinate as integer (multiplied by 1,000,000)</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("The WGS84 y coordinate as integer (multiplied by 1,000,000)")]
        [System.Xml.Serialization.XmlAttributeAttribute("y", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Y { get; set; }
        
        /// <summary>
        /// <para>As the crow flies distance from coordinate in 
        ///                    meter.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("As the crow flies distance from coordinate in meter.")]
        [System.Xml.Serialization.XmlAttributeAttribute("distance", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Distance { get; set; }
        
        /// <summary>
        /// <para>This ID can either be used as originId or destId to perform a trip request or to call a departure  board.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("This ID can either be used as originId or destId to perform a trip request or to " +
            "call a departure board.")]
        [System.Xml.Serialization.XmlAttributeAttribute("id", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Id { get; set; }
    }
    
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.206.0")]
    public partial interface IAttlistPeriodStopLocation
    {
        
        /// <summary>
        /// <para>Contains the output name of this stop or station</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Contains the output name of this stop or station")]
        string Name
        {
            get;
            set;
        }
        
        /// <summary>
        /// <para>The WGS84 x coordinate as integer (multiplied by 1,000,000)</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("The WGS84 x coordinate as integer (multiplied by 1,000,000)")]
        int X
        {
            get;
            set;
        }
        
        /// <summary>
        /// <para>The WGS84 y coordinate as integer (multiplied by 1,000,000)</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("The WGS84 y coordinate as integer (multiplied by 1,000,000)")]
        int Y
        {
            get;
            set;
        }
        
        /// <summary>
        /// <para>As the crow flies distance from coordinate in 
        ///                    meter.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("As the crow flies distance from coordinate in meter.")]
        int Distance
        {
            get;
            set;
        }
        
        /// <summary>
        /// <para>This ID can either be used as originId or destId to perform a trip request or to call a departure  board.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("This ID can either be used as originId or destId to perform a trip request or to " +
            "call a departure board.")]
        string Id
        {
            get;
            set;
        }
    }
}
