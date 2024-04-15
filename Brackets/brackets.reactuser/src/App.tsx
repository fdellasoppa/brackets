//import { useState } from 'react'
import './App.css'

function App() {
  //const [count, setCount] = useState(0)

  return (
      <div className="page">
          <div className="sidebar">
              {/*<NavMenu />*/}
          </div>

          <main>
              <div className="top-row bg-black">
                  <div className="user">
                      <div className="user__data">
                          <p className="user__data__name">[DisplayName]</p>
                          <p className="user__data__scores">#Position - Score pts</p>
                      </div>
                      <div className="user__photo">
                          {/*@if (photo == null)*/}
                          {/*{*/}
                              <img src="images/placeholders/user-default.png" />
                            {/*}*/}
                            {/*              else*/}
                            {/*              {*/}
                            {/*                  <img src="data:image/jpeg;base64, @photo">*/}
                    {/*}*/}
                      </div>
                  </div>
              </div>

                <article className="content">
                    {/*@Body*/}
                </article>
          </main>
      </div>
  )
}

export default App
