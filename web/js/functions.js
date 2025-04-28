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
    btnCreateWeapon.addEventListener("click", createWeapon);
    btnMergeWeapon.addEventListener("click", mergeWeapons);
    slcType.addEventListener("change", function() {setSelectedType(slcType.value)});
}

//This function could be done (easier) in HTML but we will Populate Select like this.

function populateSelect(){
    slcType[slcType.length] = new Option("Melee", "melee");
    slcType[slcType.length] = new Option("Magic", "magic");
    slcType[slcType.length] = new Option("Ranged", "ranged");
}

function createWeapon(){

}

function mergeWeapons(){

}

function setSelectedType(type){
    selectedType = type;
    updateList(type);
}

function updateList(type){

}