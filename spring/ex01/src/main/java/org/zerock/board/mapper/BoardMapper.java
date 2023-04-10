package org.zerock.board.mapper;

import java.util.List;

import org.zerock.board.vo.BoardVO;

public interface BoardMapper {

	public List<BoardVO> list();
	
	public BoardVO view(long no);
	
	public int write(BoardVO vo);
	
	public int update(BoardVO vo);
	
	public int delete(BoardVO vo);
}
