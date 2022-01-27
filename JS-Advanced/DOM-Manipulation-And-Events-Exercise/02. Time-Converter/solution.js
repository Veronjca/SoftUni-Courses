function attachEventsListeners() {

    let buttons = Array.from(document.querySelectorAll('input[type=button]'))
    .forEach(x => x.addEventListener('click', onClick));

    let daysFiled = document.getElementById('days');
    let hoursField = document.getElementById('hours');
    let minutesField = document.getElementById('minutes');
    let secondsField = document.getElementById('seconds');

    function onClick(ev){
        let number = Number(ev.currentTarget.previousElementSibling.value);
        if(ev.currentTarget.id == 'daysBtn'){           
            hoursField.value = number * 24;
            minutesField.value = number * 1440;
            secondsField.value = number * 86400;
        }else if(ev.currentTarget.id == 'hoursBtn'){
            daysFiled.value = number / 24;
            minutesField.value = number * 60;
            secondsField.value = number * 3600;
        }else if(ev.currentTarget.id == 'minutesBtn'){
            daysFiled.value = number / 1440;
            hoursField.value = number / 60;
            secondsField.value = number * 60;
        }else if(ev.currentTarget.id = 'secondsBtn'){
            daysFiled.value = number / 86400;
            hoursField.value = number / 3600;
            minutesField.value = number / 60;
        }
    }
}