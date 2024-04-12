import './home.css';

const Home = () => {
  return (
    <div className="contenedor">
      <section className="section1">
        <div>
          <div className="section1-content">
            <div className="section1-text1">
              <h1>
                ¿Necesitas organizar un evento? <br />
                Event Planner lo hace por vos!
              </h1>
            </div>

            <button className="createEvent">CREAR EVENTO</button>
          </div>
        </div>
      </section>
      <section className="section2">
        <div className="section2-content">
          <p>¿Cómo Funciona?</p>
          <div className="howWork">
            <div className="howWork-content">
              <button className="howWork-btn1">
                <p>Organizadores</p>
              </button>
              <button className="howWork-btn2">
                <p>Proveedores</p>
              </button>
            </div>
          </div>
        </div>
      </section>
      <section className="section3">
        <div></div>
      </section>
    </div>
  );
};

export default Home;
