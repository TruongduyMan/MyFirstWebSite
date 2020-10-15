using MyFirstWebSite.Data;
using System.Collections.Generic;

namespace MyFirstWebSite.View_Models
{
    public class LoaiDropDownVM
    {
        public LoaiDropDownVM(IEnumerable<Loai> items, string textField, string valueField, string controlName, int? loaiDuocChon = null)
        {
            Items = items;
            DataTextField = textField;
            DataValueField = valueField;
            SelectedValue = loaiDuocChon;
            ControlName = controlName;
        }
        public string ControlName { get; set; }
        public string DataTextField { get; }
        public string DataValueField { get; }
        public IEnumerable<Loai> Items { get; }
        public int? SelectedValue { get; }
    }
}
