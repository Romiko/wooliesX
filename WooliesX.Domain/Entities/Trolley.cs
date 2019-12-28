namespace WooliesX.Domain.Entities
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class Trolley
    {
        [Newtonsoft.Json.JsonProperty("products", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<Product2> Products { get; set; } = new System.Collections.ObjectModel.Collection<Product2>();

        [Newtonsoft.Json.JsonProperty("specials", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<Special> Specials { get; set; } = new System.Collections.ObjectModel.Collection<Special>();

        [Newtonsoft.Json.JsonProperty("quantities", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<Shopping> Quantities { get; set; } = new System.Collections.ObjectModel.Collection<Shopping>();


    }
}
