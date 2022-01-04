function uppercase(words){
    words = words.toUpperCase();
    const array = [...words.matchAll(/[A-Z]+/g)];
    console.log(array.join(", "));
}

uppercase('Hi, how are you?');