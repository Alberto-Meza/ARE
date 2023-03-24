function ShowToast( message, icon, position, time, showconfirm) {

    const Toast = Swal.mixin({
        toast: true,
        position: position,
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: false,
        
    })

    Toast.fire({
        icon: icon,
        title: message
    })
}


function CustomConfirm(title, message, icon, messageBtnConfirm) {

    return new Promise((resolve) => {
        Swal.fire({
            title: title,
            text: message,
            icon: icon,
            showCancelButton: true,
            confirmButtonColor: '#03B310',
            cancelButtonColor: '#d33',
            confirmButtonText: messageBtnConfirm
        }).then((result) => {

            if (result.value) {
                resolve(true);
            }
            else {
                resolve(false);
            }

            
        })
    });
    
}

