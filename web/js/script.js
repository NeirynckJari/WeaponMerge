"use strict"

//Global variables

window.addEventListener("load", initialize)

async function initialize(){
    await fetchData();
    
    bindElements();

    addEventListeners();
}