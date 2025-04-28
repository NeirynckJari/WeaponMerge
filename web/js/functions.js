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
    btnMergeWeapon.addEventListener("click", function () {
        mergeWeapons(obj1, obj2);
    });
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
    removeSelects();
    weaponId++;
    if (weapons.filter((weapon) => weapon.Type == selectedType).length < 50) {
        const weapon = weaponList.filter(
            (weap) => weap.Type == selectedType
        )[0];
        switch (selectedType) {
            case "Melee":
                weapons.push({ weapon: weapon, id: weaponId });
                break;
            case "Magic":
                weapons.push({ weapon: weapon, id: weaponId });
                break;
            case "Ranged":
                weapons.push({ weapon: weapon, id: weaponId });
                break;
            default:
                alert("Please select a style first!");
                break;
        }
        updateWeaponList(selectedType);
    } else {
        alert("Please merge some weapons first!");
        return;
    }
}

function mergeWeapons(objectOne, objectTwo) {
    if (
        Object.keys(objectOne).length == 0 &&
        Object.keys(objectTwo).length == 0
    ) {
        alert("Need to select two objects to merge!");
        return;
    } else {
        //problems here
        const weaponIndexOne = weapons.findIndex((w) => w.weapon.id === objectOne.id);
        const weaponIndexTwo = weapons.findIndex((w) => w.weapon.id === objectTwo.id);
        weapons.unshift({weapon:
            weaponList.filter((weapon) => weapon.Type == weaponIndexOne.weapon.Type)[
                weaponIndexOne.Level + 1
            , weaponIndexOne.id]},
            1
        );
        weapons.splice(weaponIndexOne, 1);
        weapons.splice(weaponIndexTwo, 1);
        updateWeaponList(selectedType);
    }
}

function setSelectedType(type) {
    selectedType = type;
    updateWeaponList(type);
}

function updateWeaponList(selectedType) {
    playField.innerHTML = "";
    if (selectedType != null) {
        weapons
            .filter((weapon) => weapon.weapon.Type == selectedType)
            .forEach((weapon) => {
                visualizeWeapon(weapon);
            });
    }
}

function visualizeWeapon(weapon) {
    const newImg = document.createElement("img");
    newImg.src = weapon.weapon.img;
    newImg.dataset.id = weapon.id;
    newImg.addEventListener("click", function () {
        selectWeapon(this);
    });
    playField.append(newImg);
}

function selectWeapon(image) {
    const clickedWeapon = weapons.find(
        (weapon) => weapon.id == image.dataset.id
    );
    if (Object.keys(obj1).length === 0) {
        obj1 = clickedWeapon.weapon;
        image.classList.add("selected");
    } else if (Object.keys(obj2).length === 0) {
        obj2 = clickedWeapon.weapon;
        image.classList.add("selected");
    } else if (Object.keys(obj1).length > 0 && Object.keys(obj2).length > 0) {
        removeSelects();
        obj1 = clickedWeapon.weapon;
        image.classList.add("selected");
    }
}

function removeSelects() {
    const allImages = [...document.querySelectorAll("img")];
    allImages.forEach((image) => {
        image.classList.remove("selected");
    });
    obj1 = {};
    obj2 = {};
}
