console.log('Hello World!');
//let name ='nameing';
//console.log(name);
document.write('hi');
let n = true
let n1= 34.9
let b = undefined


//object

let person = {
    name: 'Mosh',
    age: 30
}
person.age = 10
person['name'] = 'Mary'

console.log(person)

//array

let selectedColors = ['red', 'blue']

selectedColors[2] = 'green'
console.log(selectedColors)

//functions

function greet(va){
    alert(va+' welcome!')
}

greet('hi' )

function nu(number){
    return number*number
}
console.log(nu(5))