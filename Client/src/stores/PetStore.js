import AppDispatcher from '../dispatcher/AppDispatcher';
import ActionConstants from '../constants/ActionConstants';
import * as EventEmitter from 'eventemitter3';

const CHANGE_EVENT = 'PetChange';
var pets = [];

function createPet(inPetText) {
    pets = pets.concat(inPetText);
}

class PetStore extends EventEmitter {
    getPets() {
        return pets;
    }

    emitChange() {
        this.emit(CHANGE_EVENT);
    }

    addChangeListener(inCallback) {
        this.on(CHANGE_EVENT, inCallback);    
    }

    removeChangeListener(inCacllback) {
        this.removeListener(CHANGE_EVENT, inCacllback);
    }
}

var PetStoreObj = new PetStore();

AppDispatcher.register(function (action) {
    var text;
    
    switch (action.actionType) {
        case ActionConstants.PET_CREATE:
            createPet(action.text);
            PetStoreObj.emitChange();
            break;
        case ActionConstants.PET_LOAD:        
            pets = action.initialPets;
            PetStoreObj.emitChange();
            break;
        default:
            break;
    }
});

export default PetStoreObj;
