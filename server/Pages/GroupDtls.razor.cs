using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;

namespace RadzenDh5.Pages
{
    public partial class GroupDtlsComponent
    {
        [Inject] protected RadzenDh5.Data.Mark10Sqlexpress04Context db1 { get; set; }

        public string value;
        public IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.UserMst> customers;
        //IEnumerable<Customer> customCustomersData;

        IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GroupMst> _getGroupMstsResult;
        protected IEnumerable<RadzenDh5.Models.Mark10Sqlexpress04.GroupMst> getGroupMstsResult
        {
            get
            {
                return _getGroupMstsResult;
            }
            set
            {
                if (!object.Equals(_getGroupMstsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getGroupMstsResult", NewValue = value, OldValue = _getGroupMstsResult };
                    _getGroupMstsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        //protected  async System.Threading.Tasks.Task Load()
        //{
        //    var mark10Sqlexpress04GetGroupMstsResult = await Mark10Sqlexpress04.GetGroupMsts();
        //    getGroupMstsResult = mark10Sqlexpress04GetGroupMstsResult;
        //}


        protected override void OnInitialized()
        {
          //  customers = dbContext.Customers.ToList();

            customers = db1.UserMsts.ToList();

        }



        public void OnChange(object value, string name)
        {
            var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

        }


    }
}
