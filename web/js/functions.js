async function fetchData(path){ //add path
    await fetch(path)
    .then(response => response.json())
    .then(data => weaponList = data);
}

function bindElements(){

}

function addEventListeners(){
    
}