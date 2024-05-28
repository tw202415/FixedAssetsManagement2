// Models/Asset.cs
using System;

namespace FixedAssetsManagement2.Models
{
    public class Asset
    {
        public string AssetId { get; set; }
        public string AssetName { get; set; }
        public string Specification { get; set; }
        public int Quantity { get; set; }
        public decimal OriginalCost { get; set; }
        public decimal BookValue { get; set; }
        public decimal AccumulatedDepreciation { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public int DepreciationMethodId { get; set; }
        public int UsefulLifeId { get; set; }
        public int AccountCodeId { get; set; }
        public int DepartmentId { get; set; }
        public int AssetCategoryId { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
}
