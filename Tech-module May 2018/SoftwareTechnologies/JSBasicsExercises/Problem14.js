function solve (input){
    for (line of input){
        let obj = JSON.parse(line);
        console.log(`Name: ${obj.name}`);
        console.log(`Age: ${obj.age}`);
        console.log(`Date: ${obj.date}`);
    }
}