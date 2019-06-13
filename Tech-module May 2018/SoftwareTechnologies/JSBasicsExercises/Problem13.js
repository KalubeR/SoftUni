function solve (arr){
    let obj = {};
    for (let i = 0; i < arr.length; i++){
        let splitted = arr[i].split(" -> ");
        let name = splitted[0];
        let age = splitted[1];
        let grade = splitted[2];
        obj = { "Name": name, "Age": age, "Grade": grade};
    }

    console.log("Name: " + obj.Name);
    console.log("Age: " + obj.Age);
    console.log("Grade: " + obj.Grade);
}