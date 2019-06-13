function solve(arr){
    let length = Number(arr[0]);
    let newArr = [];

    for (let i = 0; i < length; i++){
        newArr[i] = 0;
    }


    for (let i = 1; i < arr.length; i++){
        let splitted = arr[i].split(" - ");
        let index = splitted[0];
        let value = splitted[1];
        newArr[index] = value;
    }

    for (let i = 0; i < newArr.length; i ++){
        console.log(newArr[i]);
    }
}