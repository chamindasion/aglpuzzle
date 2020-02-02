import * as React from 'react';
import * as ReactDOM from 'react-dom';
import PetStore from '../stores/PetStore';
import PetAction from '../actions/PetAction';
import PetAppList from '../components/PetAppList';

export default class PetApp extends React.Component<{}, {}> {
    //********** React Component LifeCycle **********    

    constructor(props) {
        super(props);        
    }            

    componentDidMount() {        
        PetStore.addChangeListener(this.changeHandler.bind(this));                 
    }

    componentWillUnmount() {
        PetStore.removeChangeListener(this.changeHandler.bind(this));
        
    }

    //********** Features **********
    changeHandler() {
        this.setState({ pets: PetStore.getPets() });
    }

    public handleAddPet() {
        var newPet = ReactDOM.findDOMNode<HTMLInputElement>(this.refs["txtT"]).value;
        new PetAction().createPet(newPet);
        ReactDOM.findDOMNode<HTMLInputElement>(this.refs["txtT"]).value = '';
    }

    //********** DOM **********
    render() {
        return (
            <div>                
                <PetAppList/>
            </div>

        );
    }
}
