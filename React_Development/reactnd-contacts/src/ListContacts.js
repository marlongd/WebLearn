import React, { Component } from 'react';
import PropTypes from 'prop-types'
import escapeStringRegexp from 'escape-string-regexp';
import sortBy from 'sort-by'

class ListContacts extends Component{

state ={
    query: ''
}

updateQuery = (query) =>{
    this.setState({query: query.trim()})
}


render(){
    const{contacts, onDeleteContact} = this.props
    const{ query} = this.state

    let contactsToShow
    if(query){
        const match = new RegExp(escapeStringRegexp(query), 'i')
        contactsToShow = contacts.filter((contact) => match.test(contact.name))
    }
    else{
        contactsToShow =contacts
    }
    contactsToShow.sort(sortBy('name'))
        return(
            <div className='list-contacts'>
                {/*JSON.stringify(this.state)*/}
                <div className='list-contacts-top'>
                    <input
                    className='search-contacts'
                    type='text'
                    placeholder='Search Contacts'
                    value={query}
                    onChange={(event)=> this.updateQuery(event.target.value)}
                    />
            </div>
            {contactsToShow.length !== contacts.length && (
                <div className='showing-contacts'>
                    <span>Now Showing {contactsToShow.length} of {contacts.length} total</span>
                    
                </div>
            )}

            <ol className='contact-list'>
               {contactsToShow.map((contact) => (
                   <li key ={contact.id} className='contact-list-item'>
                       <div className='contact-avatar' style={{
                        backgroundImage: `url(${contact.avatarURL})`    
                       }}>

                       </div>
                       <div className='contact-details'>
                           <p>{contact.name}</p>
                           <p>{contact.email}</p>
                       </div>
                       <button onClick={() => onDeleteContact(contact)} className='contact-remove'>Remove</button>
                   </li>
               ))} 
            </ol>
            </div>
        );
}


static PropTypes={
    contacts: PropTypes.array.isRequired,
    onDeleteContact: PropTypes.func.isRequired
}
}
export default ListContacts