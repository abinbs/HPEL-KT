
//if elseif else
let age = 9

if (age > 18){
    console.log('Adult')
}
else if (age > 14 && age < 18){
    console.log('teenager')
}
else{
    console.log('child')
}

// for loop

for(let i = 0; i <= 5; ++i){
    console.log(i)
}
//while loop
let i=0;
while(i<= 5){
    console.log(i)
    i++
}

//do while

let j=0;
do {
    console.log(j)
    j++
}while(j<= 5)

// for in
let person = {
    name: 'Mosh',
    age: 30,
}
for(let key in person){
    console.log(key, person[key])
}

// for of

const colors = ['red', 'blue', 'green']
for (let col of colors){
    console.log(col)
}

