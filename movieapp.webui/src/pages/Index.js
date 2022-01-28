import logo from '../logo.svg';
import '../App.css';
import { Col, Label, Row } from 'reactstrap';
import TopMovies from '../pages/Movies/TopMovies'
import UpcomingMovies from './Movies/UpcomingMovies';
import RecommendedMovies from './Movies/RecommendedMovies';

function Index() {
  return (
    <Row>
      <Col md="6" style={{maxHeight: "900px", overflowY: "scroll", overflowX: "hidden"}}>
        {HeadLabel("TOP 10")}
        <div style={{ height: "85px" }}></div>
        <TopMovies showItem="3" />
      </Col>
      <Col md="6" style={{maxHeight: "900px", overflowY: "scroll", overflowX: "hidden"}}>
        {HeadLabel("Yakında Eklenecek Filmler")}
        <UpcomingMovies showItem="3" />
      </Col>
      <Col md="12" style={{maxHeight: "900px", overflowY: "scroll", overflowX: "hidden"}}>
        {HeadLabel("Önerilen Filmler")}
        <RecommendedMovies showItem="5" />
      </Col>
    </Row>    
  );
}

function HeadLabel(text) {
  return <Label style={{ fontSize: "32px", textAlign: "center", width: "100%", margin: "15px" }}>{text}</Label>;
}

export default Index;
