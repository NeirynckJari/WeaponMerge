"use strict"

//Global variables

let weaponList = []; // fetched JSON data gets inserted here
let selectedType; // this to control the list
let playField, slcType;
let btnCreateWeapon, btnMergeWeapon;
let weapons = [];
let obj1 = {}, obj2 = {};
let weaponId = 0;

window.addEventListener("load", initialize)

async function initialize(){
    await fetchData("https://neirynckjari.github.io/WeaponMerge/weapons.json");
    
    bindElements();

    addEventListeners();

    populateSelect();
}