import { useEffect, useState } from 'react'
import MovieService from "../../library/Movie/MovieService";
import eMovieType from "../../library/Movie/eMovieType";
import { CardGroup, Col, Form, FormGroup, Input, Label, Row } from 'reactstrap';
import MovieItem from './MovieItem';
import Chunk from '../../library/Movie/MovieHelper';

function UpcomingMovies(props) {
  const [movieList, setMovieList] = useState([]);
  const [page, setPage] = useState(1);
  const [limit, setLimit] = useState(10);
  const [pageSize, setPageSize] = useState(10);
  const movieType = eMovieType.UpComing;

  var showItem = props.showItem !== undefined ? props.showItem : 5;

  async function GetMovieList(_page) {    
    let response = await MovieService.GetList(_page, limit, movieType);
    setPageSize(response.pageSize);
    setMovieList(Chunk(response.data, showItem));
  }

  function FetchMovies(evt) {
    var newpage = evt.target.value;
    setPage(newpage);
    GetMovieList(newpage);
  }

  useEffect(() => {
    GetMovieList(page);
  }, []);

  return (
    <>
      <Row>
        <Col md={showItem == 3 ? 5 : 8}></Col>
        <Col md={showItem == 3 ? 4 : 2}>
          <Form>
            <FormGroup>
              <Label>Gösterilmesi istenen film sayısı</Label>
              <Input id="limit" onChange={(evt) => setLimit(evt.target.value)} name="text" type="text" value={limit} />
            </FormGroup>
          </Form>
        </Col>
        <Col md={showItem == 3 ? 3 : 2}>
          <Form>            
            <FormGroup>
              <Label>Sayfa seçin</Label>
              <Input id="pageSelect" onChange={(evt) => FetchMovies(evt)} name="select" type="select">
                {GetPageOptions(pageSize)}
              </Input>
            </FormGroup>
          </Form>
        </Col>
      </Row>
      {RenderMovieGroup(movieList)}
    </>
  )
}

function GetPageOptions(pageSize) {
  var optionArr = [];
  for (let index = 1; index <= pageSize; index++) {
    optionArr.push(<option key={index} value={index}>{index}</option>);
  }
  return optionArr;
}

function RenderMovieGroup(movieList) {
  return movieList.map((array, index) => {
    return (
      <CardGroup key={index}>
        {
          RenderMovieList(array, index)
        }
      </CardGroup>
    )
  })
}

function RenderMovieList(array, index) {
  return array.map((row, subkey) => {
    return (
      <MovieItem id={row.id} imagePath={row.imagePath} title={row.title} overview={row.overview} key={index + "_" + subkey} />
    )
  });
}

export default UpcomingMovies;
