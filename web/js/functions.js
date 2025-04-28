async function fetchData(path) {
    //add path
    await fetch(path)
        .then((response) => response.json())
        .then((data) => (weaponList = data));
}

function bindElements() {
    playField = document.querySelector("#play-field");
    slcType = document.querySelector("#weapon-style");
    btnCreateWeapon = document.querySelector("#create-weapon");
    btnMergeWeapon = document.querySelector("#merge-weapons");
}

function addEventListeners() {
    btnCreateWeapon.addEventListener("click", function () {
        createWeapon(selectedType);
    });
    btnMergeWeapon.addEventListener("click", mergeWeapons);
    slcType.addEventListener("change", function () {
        setSelectedType(slcType.value);
    });
}

//This function could be done (easier) in HTML but we will Populate Select like this.

function populateSelect() {
    slcType[slcType.length] = new Option("Melee", "Melee");
    slcType[slcType.length] = new Option("Magic", "Magic");
    slcType[slcType.length] = new Option("Ranged", "Ranged");
}

function createWeapon(selectedType) {
    if (weapons.filter((weapon) => weapon.Type == selectedType).length < 50){
    const weapon = weaponList.filter((weap) => weap.Type == selectedType)[0];
    switch (selectedType) {
        case "Melee":
            weapons.push(weapon);
            break;
        case "Magic":
            weapons.push(weapon);
            break;
        case "Ranged":
            weapons.push(weapon);
            break;
        default:
            alert("Error!");
            break;
    }
    updateWeaponList(selectedType);
} else {
    alert("Please merge some weapons first!");
    return;
}}

function mergeWeapons() {}

function setSelectedType(type) {
    selectedType = type;
    updateWeaponList(type);
}

function updateWeaponList(selectedType) {
    playField.innerHTML = "";
    if (selectedType != null) {
        weapons
            .filter((weapon) => weapon.Type == selectedType)
            .forEach((weapon) => {
                visualizeWeapon(weapon);
            });
    }
}

function visualizeWeapon(weapon){
    const newImg = document.createElement("img");
    newImg.src = weapon.img;
    playField.append(newImg);
}
