package org.zerock.board.service;

import java.util.List;

import javax.inject.Inject;

import org.springframework.stereotype.Service;
import org.zerock.board.mapper.BoardMapper;
import org.zerock.board.vo.BoardVO;


@Service
public class BoardServiceImpl {
	
	
	@Inject
	private BoardMapper mapper;
	
	public List<BoardVO> list() {
		return mapper.list();
	}
}
