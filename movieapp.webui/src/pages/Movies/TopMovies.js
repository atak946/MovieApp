import { useEffect, useState } from 'react'
import MovieService from "../../library/Movie/MovieService";
import eMovieType from "../../library/Movie/eMovieType";
import { CardGroup } from 'reactstrap';
import MovieItem from './MovieItem';
import Chunk from '../../library/Movie/MovieHelper';

function TopMovies(props) {
  const [movieList, setMovieList] = useState([]);
  const [page, setPage] = useState(1);
  const [limit, setLimit] = useState(10);
  const movieType = eMovieType.Top10;
  
  var showItem = props.showItem !== undefined ? props.showItem : 5;

  useEffect(() => {
    async function GetMovieList() {
      let response = await MovieService.GetList(page, limit, movieType);
      setMovieList(Chunk(response.data, showItem));
    }

    GetMovieList();
  }, []);

  return RenderMovieGroup(movieList);
}

function RenderMovieGroup(movieList){
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

function RenderMovieList(array, index){
  return array.map((row, subkey) => {
    return (
      <MovieItem id={row.id} imagePath={row.imagePath} title={row.title} overview={row.overview} key={index + "_" + subkey} />
    )
  });
}

export default TopMovies;
