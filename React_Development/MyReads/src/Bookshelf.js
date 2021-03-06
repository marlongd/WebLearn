import React, { Component } from "react";

class Bookshelf extends Component{
    render(){

      const{books, ShelfName, onMoveTo} = this.props
      let booksToShow
      if(ShelfName){
          booksToShow = books.filter((book) => book.shelf === ShelfName)
      }
      else{
        booksToShow =books
      }



        return(
            <div className="list-books-content">
            {/*JSON.stringify(ShelfName)*/}
              {/*JSON.stringify(booksToShow)*/}
              <div>
                <div className="bookshelf">
                  <h2 className="bookshelf-title">{ShelfName}</h2>
                  <div className="bookshelf-books">
                    <ol className="books-grid">
                      {booksToShow.map((book) =>(
                        <li key ={book.id}>
                        <div className="book">
                          <div className="book-top">
                            <div className="book-cover" style={{ width: 128, height: 193, backgroundImage: `url(${book.imageLinks.thumbnail})` }}></div>
                            <div className="book-shelf-changer">
                              <select value={ShelfName}
                              onChange={(event)=> onMoveTo(book, event.target.value)}>
                                <option value="move" disabled>Move to...</option>
                                <option value="currentlyReading">Currently Reading</option>
                                <option value="wantToRead">Want to Read</option>
                                <option value="read">Read</option>
                                <option value="none">None</option>
                              </select>
                            </div>
                          </div>
                          <div className="book-title">{book.title}</div>
                          <div className="book-authors">{book.authors}</div>
                        </div>
                      </li>
                      ))}
                    </ol>
                  </div>
                </div>

              </div>
            </div>

        )
    }
}

export default Bookshelf