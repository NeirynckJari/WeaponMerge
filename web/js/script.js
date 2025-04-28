"use strict"

//Global variables

let weaponList = []; // fetched JSON data gets inserted here
let selectedType; // this to control the list
let playField, slcType;
let btnCreateWeapon, btnMergeWeapon;

window.addEventListener("load", initialize)

async function initialize(){
    await fetchData("https://neirynckjari.github.io/WeaponMerge/weapons.json");
    
    bindElements();

    addEventListeners();
}