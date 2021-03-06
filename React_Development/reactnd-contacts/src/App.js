import React, { Component } from 'react';
import { Route } from 'react-router-dom';
import CreateContact from './CreateContact';
import ListContacts from './ListContacts'
import * as ContactsAPI from './utils/ContactsAPI'


class App extends Component {
  state = {
    screen: 'list', //list, create
    contacts: []
  }
  componentDidMount(){
    ContactsAPI.getAll().then((contacts) => {
      this.setState({contacts: contacts})
    })
  }

  
  removeContact = (contact) => {
    this.setState((state) => ({
      contacts: state.contacts.filter((c) => c.id !== contact.id)
    }))

    ContactsAPI.remove(contact)
  }

  render() {
    return (
      <div>
        <Route exact path="/" render={() =>(
          <ListContacts 
          contacts={this.state.contacts} 
          onDeleteContact={this.removeContact}/>
        )
        }/>
        
        <Route path="/create" component={CreateContact}/>
        
      </div>
    )
  }
}

export default App;
