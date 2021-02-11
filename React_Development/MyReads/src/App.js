import React from 'react'
import * as BooksAPI from './BooksAPI'
import Bookshelf from './Bookshelf'
import './App.css'
import AddBook from './AddBook'
import { Route } from 'react-router-dom'
import { Link } from 'react-router-dom'

class BooksApp extends React.Component {
  state = {
    /**
     * TODO: Instead of using this state variable to keep track of which page
     * we're on, use the URL in the browser's address bar. This will ensure that
     * users can use the browser's back and forward buttons to navigate between
     * pages, as well as provide a good URL they can bookmark and share.
     */
    books: [],
    showSearchPage: true
  }

  componentDidMount(){
    BooksAPI.getAll().then((books) =>{
      this.setState({books: books})
    })
  }

  changeBookShelf = (bookIn, bookshelf) => {
    if(this.state.books.indexOf(bookIn) !== -1){
    this.setState(prevState => ({
      books: prevState.books.map(
        (book) => book.id === bookIn.id? { ...book, shelf: bookshelf }: book
      )
      }
    ))
    }
    else{
      this.setState(prevState => ({
        books: [...prevState.books, {...bookIn, shelf: bookshelf}]
      }))
    }
    
    BooksAPI.update(bookIn, bookshelf)
  }
  /*changeBookShelf = (bookIn, bookshelf) => {
    this.setState(prevState => ({
      books: prevState.books.map(
        (book) => book.id === bookIn.id? { ...book, shelf: bookshelf }: book
      )
    }))
    
    BooksAPI.update(bookIn, bookshelf)
  }*/

  render() {
    return (
      <div className="app">
        
       <Route exact path ="/" render={() =>(
         <div className="list-books">
              
         <div className="list-books-title">
           <h1>MyReads</h1>
         </div>
         
         <Bookshelf 
         ShelfName ={"currentlyReading"}
         books={this.state.books}
         onMoveTo={this.changeBookShelf}/>

         <Bookshelf 
         ShelfName ={"wantToRead"}
         books={this.state.books}
         onMoveTo={this.changeBookShelf}/>

         <Bookshelf 
         ShelfName ={"read"}
         books={this.state.books}
         onMoveTo={this.changeBookShelf}/>


          <div className="open-search">
          <Link to="/search"><button>Add a Book</button></Link>
          </div>
         </div>
       )}
       />
       <Route path ="/search" render={() =>(
         <AddBook 
         onMoveTo={this.changeBookShelf}/>
       )}
       />
      

      </div>
    )
  }
}

export default BooksApp
