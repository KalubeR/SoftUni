function solve(arr){
    let result = [];
    for (let i = 0; i < arr.length; i++){
        let splitted = arr[i].split(" ");
        let command = splitted[0];
        let value = Number(splitted[1]);

        if (command == "add"){
            result.push(value);
        }

        if (command == "remove") {
            result.splice(value, 1);
        }
    }

    for (let number of result){
        console.log(number);
    }
}