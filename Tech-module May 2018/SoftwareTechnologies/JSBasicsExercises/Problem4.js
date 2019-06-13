function solve(arr){
    let x = Number(arr[0]);
    let y = Number(arr[1]);
    let z = Number(arr[2]);
    let counter = 0;
    if (x < 0){
        counter++;
    }
    if (y < 0){
        counter++;
    }
    if (z < 0){
        counter++;
    }

    if (x == 0 || y ==0 || z == 0) {
        console.log("Positive");
    }
    if (counter % 2 !== 0){
        console.log("Negative");
    }
    else{
        console.log("Positive");
    }


}