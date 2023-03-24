using System;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.JSInterop;

namespace ARE.WEB.Helpers
{
	public static class IJExtensions
	{
		public static ValueTask<object> MostrarMensaje(this IJSRuntime js, string title, string message, TypeAlert typeAlert) {

            return js.InvokeAsync<object>("Swal.fire",title,message, typeAlert.ToString());
		}


        public static ValueTask<object> ShowToast(this IJSRuntime js, string mensaje, TypeAlert typeAlert, AlertPosition position, bool showConfirmButton, int time ) 
        {
            
            return js.InvokeAsync<object>("ShowToast", mensaje, typeAlert.ToString(), position.ToString().Replace("_", "-"), time,showConfirmButton);
        }

        public async static ValueTask<bool> Confirm(this IJSRuntime js, string title, string mensaje, string messageBtnConfirm, TypeAlert typeAlert)
        {

            return await js.InvokeAsync<bool>("CustomConfirm", title , mensaje, typeAlert.ToString(), messageBtnConfirm);
        }


    }

    public enum AlertPosition
    {
        top
       , top_start
       , top_end
       , center
       , center_start
       , center_end
       , bottom
       , bottom_start
       , bottom_end
    }

    public enum TypeAlert {
        iconwarning
            , error
            , success
            , info
            , question
    }
}

