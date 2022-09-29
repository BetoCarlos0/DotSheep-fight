// $(function () {
//     PlaceholderElement.on('click', '[data-save="modal"]', function (event) {
//         event.preventDefault();
//         var form = $(this).parents('.modal').find('form');
//         var actionUrl = form.attr('action');
//         var sendData = form.serialize();
//         $.post(actionUrl, sendData).done(function (data) {
//             location.reload();
//         })
//     })
// })

//var btnClose = document.querySelector('.close-preview-js');
//		var output = document.getElementById("new");
//		var loaderFile = function(event){
//		var reader = new FileReader();
//      reader.onload = function() {
//				output.style.display = "block";
//				btnClose.style.display = "block";
//				output.style.backgroundImage = "url("+reader.result+")";
//		  }
//			reader.readAsDataURL(event.target.files[0]);
//		}

//		var editarAvatar = document.querySelector(".editar-content");
//		var buttonFile = document.getElementById("file-preview-js");

//		editarAvatar.addEventListener("click", function(){
//			buttonFile.click();
//		});

//		btnClose.addEventListener("click", function(){
//			btnClose.style.display = "none";
//			output.style.backgroundImage = "url('')";
//			document.getElementById("file-preview-js").value = "";
//		});

var btnClose = document.querySelector('.close-preview-js');
var output = document.getElementById("new");
function loaderFile(event){
    var reader = new FileReader();
    reader.onload = function() {
        output.style.display = "block";
        btnClose.style.display = "block";
        output.style.backgroundImage = "url("+reader.result+")";
    }
    reader.readAsDataURL(event.target.files[0]);
}

var editarAvatar = document.querySelector(".editar-content");
var buttonFile = document.getElementById("foto");

editarAvatar.addEventListener("click", function(){
    buttonFile.click();
});

btnClose.addEventListener("click", function(){
    btnClose.style.display = "none";
    output.style.backgroundImage = "url('')";
    document.getElementById("foto").value = "";
});



let form = document.querySelector("#form");

async function PostUser(event) {
    event.preventDefault();

    let nome = document.querySelector("#name");
    let foto = document.querySelector("#foto");
    let message = document.querySelector("#message");

    let result = navigator.userAgent.split(/[\s()/]/);
    const getModelo = (element) => element == "AppleWebKit";
    let modelo = result[result.findIndex(getModelo) - 2];

    message.innerHTML = '<div class="spinner-grow test-warning" role="status"><span class="visually-hidden">Salvando...</span></div>'

    let user = {
        Name: nome.value,
        Device: modelo,
        Foto: foto.files[0]
    };

    let response;
    let json;

    try {
        response = await fetch("https://localhost:7113/Home/Create", {
            method: 'POST',
            headers: {
                'Content-type': 'application/json;',
            },
            body: JSON.stringify(user),
        });

        json = await response.json();
        if (response.ok === true) message.innerHTML = '<span class="test-warning"Salvo</span';
        else if (response.ok === false) throw new Error(json.message);
    }catch (err) {
        json = null;
        alert(err.message);
    } finally {
        message.innerHTML = '';
    }
}

form.addEventListener("submit", PostUser);

//form.addEventListener("submit", function(event){
//    event.preventDefault();

//    let dados = {
//        Name: nome.value,
//        Device: modelo,
//        Foto: foto.files[0]
//    };
//    console.log(dados);
//    alert("Salvo")
//    fetch('https://localhost:7113/Home/Create', {
//        method: 'POST',
//        body: JSON.stringify(dados)
//    })
//        .then(function (response) {
//            return console.log(response.json())
//    })
//})