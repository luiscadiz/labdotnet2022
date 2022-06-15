
const form = document.getElementById('form');
const inputs = document.querySelectorAll('#form input');
const btn_clean = document.getElementById('form_btn_clear');

const expressions = {
	names: /^[a-zA-ZÀ-ÿ\s]{2,40}$/, // Letras y espacios, pueden llevar acentos.
	// password: /^.{4,12}$/, // 4 a 12 digitos.
	// correo: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/,
	// telefono: /^\d{7,14}$/ // 7 a 14 numeros.
}

// Este objeto se usara para validar los campos en el submit
const campos = {
    form__name: false,
    form__last_name: false,
    form__business: false
}

const validateForm = (e) => {
   switch(e.target.name){
        case "name":
            validateInput(expressions.names,e.target,'form__name');
            break
        case "lastName":
            validateInput(expressions.names,e.target,'form__last_name');
            break
        case "business":
            validateInput(expressions.names,e.target,'form__business'); 
            break
   }
}

validateInput = (expresion, input, campo) => {
    if(expresion.test(input.value)){
        document.getElementById(campo).classList.remove('input__incorrect');
        campos[campo] = true;
    }else{
        document.getElementById(campo).classList.add('input__incorrect') 
        campos[campo] = false;
    }
}

//Verifica cada caracter ingresado para hacer la validación.
inputs.forEach((input) => {
    input.addEventListener('keyup', validateForm);
    input.addEventListener('blur', validateForm);
})


//Validación del submit
form.addEventListener('submit', (e) => {
    e.preventDefault();
   
    let validaCampos = campos.form__name && campos.form__last_name && campos.form__business;
    console.log()
    if(validaCampos)
    {
        document.getElementById('form__mensaje-error').style.display = 'none';
        document.getElementById('form__mensaje-exito').style.display = 'block';
    }
    else{
        document.getElementById('form__mensaje-error').style.display = 'block';
    }
    
})

btn_clean.addEventListener('click', (e) => {
    e.preventDefault();
    form.reset();
})

