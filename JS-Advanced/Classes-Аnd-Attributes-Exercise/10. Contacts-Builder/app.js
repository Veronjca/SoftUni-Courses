class Contact {
  constructor(firstName, lastName, phone, email) {
   debugger;
    this.firstName = firstName;
    this.lastName = lastName;
    this.phone = phone;
    this.email = email;
    this.online = false;
  }
  get online(){
      return this.online;
  }
  set online(value){
      this.online = value;
      if(this.online){

      }
  }
  render(id){
      let parent = document.querySelector(`#${id}`);
      let article = document.createElement('article');
      let firstDiv = document.createElement('div');
      let secondDiv = document.createElement('div');
      let button = document.createElement('button');
      let firstSpan = document.createElement('span');
      let secondSpan = document.createElement('span');

      firstDiv.classList.add('title');
      firstDiv.textContent = `${this.firstName} ${this.lastName}`;
      button.textContent = '\u2139';
      button.addEventListener('click', showInfo);
      firstDiv.appendChild(button);
      secondDiv.classList.add('info');
      firstSpan.textContent = `\u260F ${this.phone}`;
      secondSpan.textContent = `\2709 ${this.email}`;
      secondDiv.appendChild(firstSpan);
      secondDiv.appendChild(secondSpan);

      article.appendChild(firstDiv);
      article.appendChild(secondDiv);
      parent.appendChild(article);


      function showInfo(){
          article.children[1].style.display = 'block';
      }
  }
}
let contacts = [
  new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
  new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
  new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com"),
];
contacts.forEach((c) => c.render("main"));

// After 1 second, change the online status to true
setTimeout(() => (contacts[1].online = true), 2000);
