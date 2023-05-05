// START -- Contact Page Email
const validateEmail = (email) => {
    return String(email)
        .toLowerCase()
        .match(
            /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
        );
};

function validate(){
    let name=$("#Name").val();
    let email= validateEmail( $("#Email").val());
    let message= $("#form-message").val();
    let subject = $("#Subject").val();
    if (name.length < 2){
        Swal.fire(
            'Ad-Soyad hatalı!',
            'Ad-Soyad Boş Geçilemez.',
            'warning'
        );
        return false;
    }
    if (!email){
        Swal.fire(
            'Email hatalı!',
            'Email Adresinizi Kontrol Ediniz.',
            'warning'
        );
        return false;
    }
    if (message.length < 5){
        Swal.fire(
            'Mesaj çok kısa!',
            'Lütfen Mesajınızı Yazınız.',
            'warning'
        );
        return false;
    }
    // if (!$("#contactGdpr").is(':checked')) {
    //     Swal.fire('Lütfen KVKK alanını işaretleyin.')
    //     return false;
    // }

    if (subject == null )
    {
        Swal.fire(
            'Konu hatalı!',
            'Başlığı Kontrol Ediniz.',
            'warning'
        );
        return false;
    }

    return true;
}

$(function () {

    $("#submitButton").click(function () {
        if (validate()){
            $.ajax({
                type: "POST",
                url: "/mail/gazikoylu",
                data: {
                    "name": $("#Name").val(),
                    "email": $("#Email").val(),
                    "subject": $("#Subject").val(),
                    "message": $("#form-message").val(),
                },
                success: function (response) {
                    Swal.fire(  'Teşekkürler '+ response.name ,  'Mesajınız bize ulaştı!',  'success');
                },
                failure: function (response) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Mail gönderilemedi!'
                    })
                },
                error: function (response) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Mail gönderilemedi!'
                    })
                }
            });
        }
    });


});
//END -- Contact Page Email

// START -- Home Page Contact Form

function validateHomePageForm(){
    let name=$("#Name").val();
    let email= validateEmail( $("#Email").val());
    let subject = $("#Subject").val();
    let message= $("#form-message").val();
 
 
    if (name.length < 2){
        Swal.fire(
            'Ad-Soyad hatalı!',
            'Ad-Soyad Boş Geçilemez.',
            'warning'
        );
        return false;
    }
    if (!email){
        Swal.fire(
            'Email hatalı!',
            'Email Adresinizi Kontrol Ediniz.',
            'warning'
        );
        return false;
    }
    if (message.length < 5){
        Swal.fire(
            'Mesaj çok kısa!',
            'Lütfen Mesajınızı Yazınız.',
            'warning'
        );
        return false;
    }

    if (subject == null )
    {
        Swal.fire(
            'Konu hatalı!',
            'Başlığı Kontrol Ediniz.',
            'warning'
        );
        return false;
    }

    return true;
}

$(function () {

    $("#submitButtonHomePage").click(function () {
        if (validateHomePageForm()){
            $.ajax({
                type: "POST",
                url: "/mail/gazikoyluhomepage",
                data: {
                    "name": $("#Name").val(),
                    "email": $("#Email").val(),
                    "subject": $("#Subject").val(),
                    "message": $("#form-message").val(),
                },
                success: function (response) {
                    Swal.fire(  'Teşekkürler '+ response.name ,  'Mesajınız bize ulaştı!',  'success');
                },
                failure: function (response) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Mail gönderilemedi!'
                    })
                },
                error: function (response) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Mail gönderilemedi!'
                    })
                }
            });
        }
    });


});

//END -- Home Page Contact Form
