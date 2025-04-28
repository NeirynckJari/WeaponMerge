async function fetchData(path){ //add path
    await fetch(path)
    .then(response => response.json())
    .then(data => weaponList = data);
}

function bindElements(){
    playField = document.querySelector("#play-field");
    slcType = document.querySelector("#weapon-style");
    btnCreateWeapon = document.querySelector("#create-weapon");
    btnMergeWeapon = document.querySelector("#merge-weapons");
}

function addEventListeners(){
    
}