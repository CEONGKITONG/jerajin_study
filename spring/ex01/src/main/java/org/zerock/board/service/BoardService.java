package org.zerock.board.service;

import java.util.List;

import org.zerock.board.vo.BoardVO;

public interface BoardService {

	public List<BoardVO> list();
	
	public BoardVO view(long no, int inc);
	
	public int write(BoardVO vo);
	
	public int update(BoardVO vo);
	
	public int delete(BoardVO vo);
}
