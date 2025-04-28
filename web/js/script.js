"use strict"

//Global variables

let weaponList = [];
let selectedType; // this to control the list

window.addEventListener("load", initialize)

async function initialize(){
    await fetchData("https://neirynckjari.github.io/WeaponMerge/weapons.json");
    
    bindElements();

    addEventListeners();
}