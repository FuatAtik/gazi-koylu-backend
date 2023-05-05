function ValidateEmailContact(mail) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(mail);
}


function validateCVForm() {
    let name = $("#Name").val();
    let email = ValidateEmailContact($("#Email").val());
    let message = $("#Message").val();
    let resume = $("#Resume").val();
    let checkKvkk = document.getElementById("KvkkCheck").checked;
    var response = grecaptcha.getResponse();

    if (response.length === 0) {
        Swal.fire('Lütfen Captcha alanını doğrulayın.')
        return false;
    }

    if (name.length < 2) {
        Swal.fire(
            'Ad-Soyad hatalı!',
            'Ad-Soyad Boş Geçilemez.',
            'warning'
        );
        return false;
    }

    if (!email) {
        Swal.fire(
            'Email hatalı!',
            'Email Adresinizi Kontrol Ediniz.',
            'warning'
        );
        return false;
    }
    if (message.length < 5) {
        Swal.fire(
            'Mesaj çok kısa!',
            'Lütfen Mesajınızı Yazınız.',
            'warning'
        );
        return false;
    }

    if (!checkKvkk) {
        Swal.fire(
            'Kvkk hatalı!',
            'Lütfen Kvkk Metnini Onaylayın',
            'warning'
        );
        return false;
    }

    if (!resume) {
        Swal.fire(
            'Bos gecilemez!',
            'Lütfen Bir Pdf Dosyasi Seciniz.',
            'warning'
        );
        return false;
    }


    if (resume != false) {
        const fileSize  = document.getElementById("Resume").files.item(0).size;
        const fileMb = fileSize / 1024 ** 2;
        if (fileMb >= 1) {
            Swal.fire(
                'Yuksek Boyut!',
                'Lütfen 1MB den küçük bir dosya seçin.',
                'warning'
            );
            return false;
        }
    }

    return true;
}




$(function() {
    $("#submitButtonCV").click(function () {
        if (validateCVForm()) {
            var fileUpload = $("#Resume").get(0);
            var files = fileUpload.files;
            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            data.append("Name", $("#Name").val());
            data.append("Email", $("#Email").val());
            data.append("Message", $("#Message").val());
            data.append("captcha", grecaptcha.getResponse());

            $.ajax({
                type: "POST",
                url: "/mail/doganlarMobilyaCV",
                contentType: false,
                processData: false,
                dataType: 'json',
                data: data,
                success: function (response) {
                    if (response.success) {
                        Swal.fire('Teşekkürler ' + $("#Name").val(), 'Mesajınız bize ulaştı!', 'success');
                        $("#submitButtonCV").hide();
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Hatayla Karşılaştık',
                            text: response.responseText
                        })
                    }

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



    ShowDates();
});

function ShowDates() {
    hidePdfs();
    const selectedDate = $("#myselect option:selected").val(); //get selected value
    const dates=document.getElementsByClassName(selectedDate); //get dates according to selected value
    $('#title-date').text(selectedDate);//update date 
    $(dates).each(function (){
        $(this).show();
    });
}

function hidePdfs(){
    const pdfs=document.getElementsByClassName('pdf-showhide');
    $(pdfs).each(function (){
        $(this).hide();
    })
}


